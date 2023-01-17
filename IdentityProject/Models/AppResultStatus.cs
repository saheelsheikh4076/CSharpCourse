﻿namespace IdentityProject.Models
{
    public class AppResultStatus
    {
        public bool IsSuccess { get; set; }
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}