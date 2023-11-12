namespace OnyxTestApp.Models
{
    public class VatVerifier
    {
        public enum VerificationStatus
        {
            Valid,
            Invalid,
            // Unable to get status (e.g. service unavailable)
            Unavailable
        }


        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="vatId"></param>
        /// <returns>Verification status</returns>
        // TODO: Implement Verify method

        public async Task<VerificationStatus> Verify(string countryCode, string vatId)
        {
            try
            {
                var service = new checkVatPortTypeClient();
                var request = new checkVatRequest
                {
                    countryCode = countryCode,
                    vatNumber = vatId
                };

                var response = await service.checkVatAsync(request);
                return response.valid ? VerificationStatus.Valid : VerificationStatus.Invalid;
            }
            catch
            {
                return VerificationStatus.Unavailable;
            }
        }
    }
}

