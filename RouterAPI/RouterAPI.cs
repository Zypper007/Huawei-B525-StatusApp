using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive;

namespace RouterAPI
{
    public class RouterAPI
    {
        // klient http do wykonywana zapytań
        private HttpClient httpClient;
        private IObservable<RouterStates> routerStates Observable.


        public RouterAPI ()
	    {
            routerStates.s
	    }


        // klasa zwraca stumień do obserwacji
        public IObservable<RouterStates> Connect(Uri url)
        {
            httpClient = new HttpClient();
            // ustawienie postawowego adresu url, powinno być adresem routera
            httpClient.BaseAddress = url;
            // wysłanie zapytania get w celu uzyskania odpowiedzi z ciasteczkiem sesji
            // nie ma możliwości zweryfikowania serwera http czy to ruter bo nie wysyła żadnych tego typu informacji
            var request = httpClient.GetAsync("");
            request.Start();
            request.Wait();
            var response = request.Result;
            response.EnsureSuccessStatusCode();

            // ustawienie sessionID do cookies
            var sessionID = from header in response.Headers where header.Key == "Set-Cookie" select header.Value;
            httpClient.DefaultRequestHeaders.Add("Cookie", sessionID.First());


            return routerStates.Next(new RouterStates());
        }
    }
}
