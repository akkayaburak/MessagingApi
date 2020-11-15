namespace MessagingApi.Services
{
    public interface IBlockService
    {
        public void Block(int blockById, int blockToId, bool decide);

        public bool IsBlocked(int blockById, int blockToId);
    }
}
