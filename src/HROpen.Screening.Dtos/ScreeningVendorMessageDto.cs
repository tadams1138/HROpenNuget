using HROpen.Common.Base;

namespace HROpen.Screening
{
    public class ScreeningVendorMessageDto
    {
        public IdentifierDto OrderId { get; set; }
        public TextDto Message { get; set; }
        public FieldDto[] Fields { get; set; }

        public class FieldDto
        {
            public string Path { get; set; }
            public TextDto Description { get; set; }
        }
    }
}