namespace HROpen.Common.Base
{
    public class AttachmentDto
    {
        public IdentifierDto Id { get; set; }
        public string Url { get; set; }
        public BinaryObjectDto Content { get; set; }
        public string[] Descriptions { get; set; }
    }
}