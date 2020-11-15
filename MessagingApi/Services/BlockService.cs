using MessagingApi.Entities;
using MessagingApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Services
{
    public class BlockService : IBlockService
    {
        private DataContext _context;

        public BlockService(DataContext context)
        {
            _context = context;
        }
        public void Block(int blockById, int blockToId, bool decide)
        {
            Block block = new Block
            {
                BlockById = blockById,
                BlockToId = blockToId
            };
            if (decide == true)
            {
                block.IsBlocked = true;
            }
            else
            {
                block.IsBlocked = false;
            }
            
            _context.Blocks.Add(block);
            _context.SaveChanges();
        }

        public bool IsBlocked(int blockById, int blockToId)
        {
            if(blockById == blockToId)
            {
                throw new AppException("User can not block him/her self.");
            }
            var block = _context.Blocks
                 .Where(u => u.BlockById == blockById)
                 .Where(b => b.BlockToId == blockToId)
                 .FirstOrDefault();
            if(block == null)
            {
                return false;
            }
            return block.IsBlocked;
        }


    }
}
