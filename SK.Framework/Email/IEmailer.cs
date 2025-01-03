﻿namespace SK.Framework.Email;

public interface IEmailer
{
    Task SendAsync<T>(IDbEmailSingleSender<T> emailSender) where T : IEmailTokens;

    Task SendAsync<T>(IDbEmailSingleSender<T> msg, List<Attachment> attachments) where T : IEmailTokens;

    Task SendAsync<T>(IFileEmailSingleSender<T> msg) where T : IEmailTokens;

    Task SendAsync<T>(IFileEmailSingleSender<T> msg, List<Attachment> attachments) where T : IEmailTokens;
}