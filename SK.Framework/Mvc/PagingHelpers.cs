﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace SK.Framework.MVC;

public static class PagingHelpers
{
    public static string ConvertToEasternArabicNumerals(string input)
    {
        var utf8Encoder = new UTF8Encoding();
        Decoder utf8Decoder = utf8Encoder.GetDecoder();
        var convertedChars = new System.Text.StringBuilder();
        var convertedChar = new char[1];
        var bytes = new byte[] { 217, 160 };
        foreach (char c in input.ToCharArray())
        {
            if (char.IsDigit(c))
            {
                bytes[1] = Convert.ToByte(160 + char.GetNumericValue(c));
                utf8Decoder.GetChars(bytes, 0, 2, convertedChar, 0);
                convertedChars.Append(convertedChar[0]);
            }
            else
            {
                convertedChars.Append(c);
            }
        }
        return convertedChars.ToString();
    }

    public static string ArabicNumber(int? number)
    {
        if (!number.HasValue)
            return "";

        if (Env.IsArabic())
            return ConvertToEasternArabicNumerals($"{number}");

        return $"{number}";
    }

    /// <summary>
    /// This is applicable for Bootstrap version 5.0
    /// </summary>
    /// <param name="html"></param>
    /// <param name="currentPage"></param>
    /// <param name="totalPages"></param>
    /// <param name="pageUrl"></param>
    /// <returns></returns>
    public static IHtmlContent BootstrapPageLinks(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
    {
        var isRtl = Env.IsRtl();
        var records = isRtl ? "سجلات" : "records";

        var currentPage = pagingInfo.CurrentPage;
        var totalPages = pagingInfo.TotalPages;

        //number of pages to be displayed
        const short max = 10;
        var level = Math.Ceiling(currentPage / (double)max) * max;

        var list = new TagBuilder("ul");
        if (isRtl)
            list.MergeAttribute("direction", "rtl");

        list.MergeAttribute("class", "pagination");

        var startPage = (int)level - max + 1;

        IHtmlContent TagMaker(string text, string? url, bool isActive)
        {
            var pageNumberTag = new TagBuilder("a");
            pageNumberTag.MergeAttribute("class", "page-link");

            if (!string.IsNullOrWhiteSpace(url))
                pageNumberTag.MergeAttribute("href", url);

            pageNumberTag.InnerHtml.AppendHtml(new HtmlString(text));

            var listItem = new TagBuilder("li");
            list.MergeAttribute("class", "page-item");

            if (isActive)
                listItem.MergeAttribute("class", "active", replaceExisting: false);

            listItem.InnerHtml.AppendHtml(pageNumberTag);
            return listItem;
        }

        IHtmlContent DirectionMaker(string icon, string url)
        {
            var linkTag = new TagBuilder("a");
            linkTag.MergeAttribute("class", "page-link");

            if (!string.IsNullOrWhiteSpace(url))
                linkTag.MergeAttribute("href", url);

            var iconTag = new TagBuilder("i");
            if (!string.IsNullOrWhiteSpace(icon))
                iconTag.MergeAttribute("class", icon);

            linkTag.InnerHtml.AppendHtml(iconTag);

            var listItem = new TagBuilder("li");
            listItem.InnerHtml.AppendHtml(linkTag);
            return listItem;
        }

        if (totalPages > 1 && currentPage != 1)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-right", pageUrl(currentPage - 1)));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left", pageUrl(currentPage - 1)));
            }
        }

        for (var i = startPage; i <= level; i++)
        {
            if (i > totalPages)
                break;

            if (i == currentPage)
                list.InnerHtml.AppendHtml(TagMaker(ArabicNumber(i) + "", "", true));
            else
                list.InnerHtml.AppendHtml(TagMaker(ArabicNumber(i) + "", pageUrl(i), false));
        }

        if (totalPages > 1 && currentPage != totalPages)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left", pageUrl(currentPage + 1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(totalPages)));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-right", pageUrl(currentPage + 1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(totalPages)));
            }
        }

        if (pagingInfo.TotalResults > 1)
            list.InnerHtml.AppendHtml(TagMaker($"{ArabicNumber(pagingInfo.TotalResults)} {records}", null, false));

        if (totalPages > 1)
        {
            //direct page navigation
            var boxTag = new TagBuilder("input");
            boxTag.MergeAttribute("placeholder", "page");
            boxTag.MergeAttribute("type", "text");
            boxTag.MergeAttribute("style", "width:60px;margin:0;");
            //long nasty javascript call. Be careful when modifying this.
            var jsNavigate = "if (event.keyCode==13){" +
                             "if(isNaN(this.value) || this.value < 1){alert('Please enter positive number');return;}" +
                             "if(this.value > " + totalPages + "){alert('Maximum number allowed is " + totalPages +
                             "');return;}" +
                             "var url ='" + pageUrl(1).Replace("page=1", "page=") + "';" + //REMEMBER that page= must be all lowercase otherwise replacement won't work
                             "url = url.replace('page=', 'page=' + this.value);" +
                             "window.location = url;" +
                             "}";

            boxTag.MergeAttribute("onkeypress", jsNavigate);

            var listItem = new TagBuilder("li");
            listItem.MergeAttribute("class", "page-item");

            var wrapper = new TagBuilder("a");
            wrapper.MergeAttribute("class", "page-link");
            wrapper.InnerHtml.AppendHtml(boxTag);
            wrapper.MergeAttribute("style", "padding-top:9px;padding-bottom:9px;");
            listItem.InnerHtml.AppendHtml(wrapper);
        }

        var result = new TagBuilder("nav");
        result.InnerHtml.AppendHtml(list);
        return result;
    }

    public static IHtmlContent BootstrapPageLinksModified(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
    {
        var isRtl = Env.IsRtl();
        var records = isRtl ? "سجلات" : "records";

        var currentPage = pagingInfo.CurrentPage;
        var totalPages = pagingInfo.TotalPages;

        //number of pages to be displayedq
        const short max = 10;
        var level = Math.Ceiling(currentPage / (double)max) * max;
        var list = new TagBuilder("ul");
        if (isRtl)
            list.MergeAttribute("direction", "rtl");

        list.MergeAttribute("class", "pagination justify-content-center");

        var startPage = (int)level - max + 1;

        IHtmlContent DirectionMaker(string icon, string url, bool isDisabled = false)
        {
            var linkTag = new TagBuilder("a");
            linkTag.MergeAttribute("class", isDisabled ? "link-dark px-2 disabled" : "link-dark px-2");
            if (isDisabled)
            {
                linkTag.MergeAttribute("style", "pointer-events:none;");
                linkTag.MergeAttribute("tabindex", "-1");
            }

            if (!string.IsNullOrWhiteSpace(url))
                linkTag.MergeAttribute("href", url);

            var iconTag = new TagBuilder("i");
            if (!string.IsNullOrWhiteSpace(icon))
            {
                iconTag.MergeAttribute("class", $"{icon} ");
                if (isDisabled)
                    iconTag.MergeAttribute("style", "color: gray;");
            }

            linkTag.InnerHtml.AppendHtml(iconTag);

            var listItem = new TagBuilder("li");
            listItem.MergeAttribute("class", "page-item");
            listItem.InnerHtml.AppendHtml(linkTag);
            return listItem;
        }

        IHtmlContent TagMaker(string text, string? url, bool isActive)
        {
            var pageNumberTag = new TagBuilder("a");
            pageNumberTag.MergeAttribute("class", "link-dark px-2");

            if (!string.IsNullOrWhiteSpace(url))
                pageNumberTag.MergeAttribute("href", url);

            pageNumberTag.InnerHtml.AppendHtml(new HtmlString(text));

            var listItem = new TagBuilder("li");
            list.MergeAttribute("class", "");

            if (isActive)
                listItem.MergeAttribute("class", "active", replaceExisting: false);

            listItem.InnerHtml.AppendHtml(pageNumberTag);
            return listItem;
        }

        if (totalPages > 1 && currentPage != 1)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi bi-arrow-right-circle", pageUrl(currentPage - 1)));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left-circle", pageUrl(currentPage - 1)));
            }
        }
        else if (totalPages > 1 && currentPage == 1)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(1), true));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi bi-arrow-right-circle", pageUrl(currentPage - 1), true));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(1), true));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left-circle", pageUrl(currentPage - 1), true));
            }
        }

        list.InnerHtml.AppendHtml(TagMaker(ArabicNumber(currentPage) + "", "", true));

        if (totalPages > 1 && currentPage != totalPages)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left-circle", pageUrl(currentPage + 1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(totalPages)));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi bi-arrow-right-circle", pageUrl(currentPage + 1)));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(totalPages)));
            }
        }
        else if (totalPages > 1 && currentPage == totalPages)
        {
            if (isRtl)
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-left-circle", pageUrl(currentPage + 1), true));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-left", pageUrl(totalPages), true));
            }
            else
            {
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi bi-arrow-right-circle", pageUrl(currentPage + 1), true));
                list.InnerHtml.AppendHtml(DirectionMaker("bi bi-arrow-bar-right", pageUrl(totalPages), true));
            }
        }

        if (totalPages > 1)
        {
            //direct page navigation
            var boxTag = new TagBuilder("input");
            boxTag.MergeAttribute("placeholder", "page");
            boxTag.MergeAttribute("type", "text");
            boxTag.MergeAttribute("style", "width:60px;margin:0;");
            //long nasty javascript call. Be careful when modifying this.
            var jsNavigate = "if (event.keyCode==13){" +
                             "if(isNaN(this.value) || this.value < 1){alert('Please enter positive number');return;}" +
                             "if(this.value > " + totalPages + "){alert('Maximum number allowed is " + totalPages +
                             "');return;}" +
                             "var url ='" + pageUrl(1).Replace("page=1", "page=") + "';" + //REMEMBER that page= must be all lowercase otherwise replacement won't work
                             "url = url.replace('page=', 'page=' + this.value);" +
                             "window.location = url;" +
                             "}";

            boxTag.MergeAttribute("onkeypress", jsNavigate);

            var listItem = new TagBuilder("li");
            listItem.MergeAttribute("class", "page-item");

            var wrapper = new TagBuilder("a");
            wrapper.MergeAttribute("class", "page-link px-2");
            wrapper.InnerHtml.AppendHtml(boxTag);
            wrapper.MergeAttribute("style", "padding-top:9px;padding-bottom:9px;");
            listItem.InnerHtml.AppendHtml(wrapper);
        }
        var result = new TagBuilder("nav");
        var block = new TagBuilder("h4");

        //var result = new TagBuilder("nav");
        block.InnerHtml.AppendHtml(list);
        result.InnerHtml.AppendHtml(block);
        return result;
    }
}