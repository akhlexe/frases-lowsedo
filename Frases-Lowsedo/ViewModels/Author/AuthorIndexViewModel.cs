using Frases_Lowsedo.DTOs;

namespace Frases_Lowsedo.ViewModels.Author
{
    public class AuthorIndexViewModel
    {
        public IList<AuthorDTO> Authors { get; set; }


        public AuthorIndexViewModel()
        {
            Authors = new List<AuthorDTO>();
        }
    }
}
