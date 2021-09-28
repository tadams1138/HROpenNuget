using HROpen.Common.Base;

namespace HROpen.Screening
{
    public class CatalogPackageDto
    {
        public Package[] Packages { get; set; }

        public class Package
        {
            public string PackageCode { get; set; }
            public TextDto PackageDescription { get; set; }
        }
    }
}