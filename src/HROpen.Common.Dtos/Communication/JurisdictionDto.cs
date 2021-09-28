namespace HROpen.Common.Communication
{
    public class JurisdictionDto
    {
        public string CountryCode { get; set; }
        public string City { get; set; }
        public AddressComponentDto[] CountrySubDivisions { get; set; }
    }
}