namespace tickethub.DTO
{
    public class MovieCastDTO
    {
        public long Id { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public ICollection<CastDTO> Casts { get; set; }
    }
}
