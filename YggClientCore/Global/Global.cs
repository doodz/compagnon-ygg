namespace YggClientCore.Global
{
    public static class GlobalLocal
    {
        public static readonly string YggIndex = "https://yggtorrent.com";
        public static readonly string YggLogin = $"{YggIndex}/user/login";
        public static readonly string YggRegister = $"{YggIndex}/user/register";
        public static readonly string YggLogout = $"{YggIndex}/user/logout";
        public static readonly string YggMyTorrent = $"{YggIndex}/user/my_torrents";
        public static readonly string YggUploadTorrent = $"{YggIndex}/user/upload_torrent";
        public static readonly string YggAccount = $"{YggIndex}/user/account";
    }
}