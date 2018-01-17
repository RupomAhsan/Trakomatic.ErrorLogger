﻿using System.Net.Mime;

namespace Notifications.Emails.Models
{
    /// <summary>
    /// Class to represent attachments on an Email.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Represent a full location of an file.
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// Represent an identifier to a inline attachment, example: src="cid:mycontentid"
        /// </summary>
        public string ContentId { get; set; }
        /// <summary>
        /// MimeType represent a type of an attachment, for exemple: MediaTypes.Image.Jpeg, MediaTypeNames.Application.Pdf
        /// </summary>
        public string MimeType { get; set; }

        public Attachment()
        {
            MimeType = MediaTypeNames.Application.Octet;
        }
    }
}
