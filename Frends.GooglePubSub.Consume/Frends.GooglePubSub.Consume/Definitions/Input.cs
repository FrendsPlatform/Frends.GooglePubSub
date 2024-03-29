﻿namespace Frends.GooglePubSub.Consume.Definitions;

using System.ComponentModel;

/// <summary>
/// Consume Task input.
/// </summary>
public class Input
{
    /// <summary>
    /// The project ID.
    /// </summary>
    /// <example>my-project-123456</example>
    public string ProjectID { get; set; }

    /// <summary>
    /// The subscription ID.
    /// </summary>
    /// <example>my-project-123456</example>
    public string SubscriptionID { get; set; }

    /// <summary>
    /// The JSON service account key that one can generate in the Google Cloud portal.
    /// </summary>
    /// <example>
    /// {
    ///      "type": "service_account",
    ///      "project_id": "something",
    ///      "private_key_id": "fdsafdsafdsalmnop12345678909876543212344",
    ///      "private_key": "-----BEGIN PRIVATE KEY-----\nMIIE.......Hw==\n-----END PRIVATE KEY-----\n",
    ///      "client_email": "someone@something.iam.gserviceaccount.com",
    ///      "client_id": "123456789012345678900",
    ///      "auth_uri": "https://accounts.google.com/o/oauth2/auth",
    ///      "token_uri": "https://oauth2.googleapis.com/token",
    ///      "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
    ///      "client_x509_cert_url": "https://www....nt.com"
    /// }
    /// </example>
    [PasswordPropertyText]
    public string ServiceAccountKeyJSON { get; set; }
}