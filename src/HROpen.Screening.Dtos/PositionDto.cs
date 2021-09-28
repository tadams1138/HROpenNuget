using HROpen.Common.Base;
using HROpen.Common.Communication;

namespace HROpen.Screening
{
    public class PositionDto : NounDto
    {
        public JurisdictionDto Jurisdiction { get; set; }
    }
}