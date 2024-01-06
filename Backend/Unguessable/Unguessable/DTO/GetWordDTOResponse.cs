using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unguessable.DTO
{
	public record GetWordDTOResponse(int ID,
	int CategoryID,
    string Word,
	string WordForbidden1,
	string WordForbidden2,
   string WordForbidden3);

}
