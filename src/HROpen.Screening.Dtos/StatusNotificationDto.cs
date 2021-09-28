using HROpen.Common.Base;

namespace HROpen.Screening
{
    public class StatusNotificationDto
    {
        public IdentifierDto OrderId { get; set; }
        public string StatusMessage { get; set; }
        public string ReportLink { get; set; }
    }
}