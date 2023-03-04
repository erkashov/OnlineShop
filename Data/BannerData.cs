namespace OnlineShop.Data
{
    public class BannerData
    {
        public string Header { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        public string Link { get; set; }

        public string LinkHeader { get; set; }
        public BannerData()
        {
            Header = "Заголовок";
            Description = "Описание";
            ImageLink = "";
            Link = "/";
            LinkHeader = "Смотреть";
        }
    }
}
