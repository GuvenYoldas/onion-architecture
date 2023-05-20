namespace GUVENYOLDAS.API.ExampleProject.Models.Base
{
    public class ResultModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        /// <summary>
        ///  -1: Catch Error
        ///   0: Başarılı
        ///  >0: özel hatalar
        /// </summary>
        public int Success { get; set; }

    }
}