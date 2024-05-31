namespace Gym.Uninove.Web.Services
{
    public class ImageUploadService
    {

        public async Task<string> UploadImageAsync(IFormFile imageFile, string uploadFolder)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Image file is required.");
            }

            // Crie um nome de arquivo exclusivo com base no GUID
            var uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";

            // Caminho completo para salvar a imagem
            var imagePath = Path.Combine(uploadFolder, uniqueFileName);

            // Salve o arquivo de imagem no servidor
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imagePath;
        }

    }
}
