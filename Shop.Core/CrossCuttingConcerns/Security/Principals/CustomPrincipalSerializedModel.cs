namespace Shop.Core.CrossCuttingConcerns.Security.Principals
{
    public class CustomPrincipalSerializedModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}
