namespace Module_1
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}";
        }
    }



}
