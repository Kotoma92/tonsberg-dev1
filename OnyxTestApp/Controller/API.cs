using OnyxTestApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnyxTestApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VatController : ControllerBase
    {
        private readonly VatVerifier _vatVerifier;

        public VatController(VatVerifier vatVerifier)
        {
            _vatVerifier = vatVerifier;
        }

        [HttpGet("{countryCode}/{vatId}")]
        public async Task<ActionResult<string>> Verify(string countryCode, string vatId)
        {
            var result = await _vatVerifier.Verify(countryCode, vatId);
            return Ok(Enum.GetName(typeof(VatVerifier.VerificationStatus), result));
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("GetRepeatedGuestNames")]
        public ActionResult<List<string>> GetRepeatedGuestNames()
        {
            var testInvoiceGroups = InvoiceGroup.CreateTestData();
            var result = OnyxTestMethods.GetRepeatedGuestNames(testInvoiceGroups);
            List<string> names = new List<string>();
            foreach (var name in result)
            {
                names.Add(name);
            }
            return Ok(names);
        }

        [HttpGet("GetTravelAgentNights/{issueDateYear}")]
        public ActionResult<List<TravelAgentInfo>> GetTravelAgentNights(int issueDateYear)
        {
            var testInvoiceGroups = InvoiceGroup.CreateTestData();
            var testTravelAgentInfos = TravelAgentInfo.CreateTestData();
            var result = OnyxTestMethods.GetTravelAgentNights(testInvoiceGroups, issueDateYear);
            foreach (var info in result)
            {
                testTravelAgentInfos.Add(info);
            }
            return Ok(testTravelAgentInfos);
        }
    }
}
