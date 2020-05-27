using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.May2020.Core.Dto
{
    public class ResponseMessagesDto
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string SuccessMessage { get; set; }
        public string FailureMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
