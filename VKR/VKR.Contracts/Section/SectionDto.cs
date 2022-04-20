namespace VKR.Contracts.Section
{
    public class SectionDto : DtoBase
    {
        /// <summary>
        /// Название раздела
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание раздела
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// порядковый номер раздела
        /// </summary>
        public int Number { get; set; }
    }
}