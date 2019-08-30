using Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System;

namespace Acerto.MarvelHeros.Almanaque.GoogleTradutorAdapter
{
    public class GoogleTradutorAdapter : IGoogleTradutorAdapter
    {
        private readonly GoogleTradutorAdapterConfiguration googleTradutorAdapterConfiguration;

        public GoogleTradutorAdapter(GoogleTradutorAdapterConfiguration googleTradutorAdapterConfiguration)
        {
            this.googleTradutorAdapterConfiguration = googleTradutorAdapterConfiguration;
        }

        public string TraduzirPtBrToEnUs(string termo)
        {
            GoogleCredential googleCredential = GoogleCredential.FromAccessToken(googleTradutorAdapterConfiguration.AccessCode);

            try
            {
                TranslationClient client = TranslationClient.Create(googleCredential);

                var response = client.TranslateText(
                text: termo,
                targetLanguage: "pt-Br",
                sourceLanguage: "en");  // English

                return response.TranslatedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}