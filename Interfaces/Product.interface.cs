namespace solvex_dominicana.Interfaces
{
    public class ProductInterface
    {
        public class ProductRequestPayload 
        {
            public string name { get; set; }
            public string description { get; set; }
        }

        public class ProductToBrandRequestPayload
        {
            public double price { get; set; }
        }
    }
}
