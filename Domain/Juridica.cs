namespace Domain
{
    public sealed class Juridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
    }
}
