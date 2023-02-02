using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUI
{
    class Global
    {
        public static string GlobalUserId { get; private set; }
        public static int GlobalId { get; private set; }

        public static int GlobalFlag { get; private set; }
        public static void SetGlabelUserId(string userID, int id)
        {
            GlobalUserId = userID;
            GlobalId = id;

        }

        public static void SetGlabelfalg( int flag)
        {
            GlobalFlag = flag;

        }


    }
}
