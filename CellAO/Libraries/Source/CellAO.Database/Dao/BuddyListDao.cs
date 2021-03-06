﻿#region License

// Copyright (c) 2005-2013, CellAO Team
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//     * Neither the name of the CellAO Team nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

namespace CellAO.Database.Dao
{
    #region Usings ...

    using System;
    using System.Collections.Generic;
    using System.Data;

    using CellAO.Database.Entities;

    using Dapper;

    using Utility;

    #endregion

    /// <summary>
    /// </summary>
    public static class BuddyListDao
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="charId">
        /// </param>
        /// <param name="buddyId">
        /// </param>
        public static void AddBuddy(int charId, int buddyId)
        {
            try
            {
                using (IDbConnection conn = Connector.GetConnection())
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("charId", charId);
                    p.Add("buddyId", buddyId);
                    conn.Execute("INSERT INTO `buddylist` VALUES (@charId, @buddyId)", p);
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorException(e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="charId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IEnumerable<DBBuddyListEntry> LoadBuddyList(int charId)
        {
            try
            {
                using (IDbConnection conn = Connector.GetConnection())
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("charId", charId);
                    return conn.Query<DBBuddyListEntry>("SELECT `BuddyID` FROM `buddylist` WHERE PlayerID = @charId", p);
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorException(e);
                return new List<DBBuddyListEntry>();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="charId">
        /// </param>
        /// <param name="buddyId">
        /// </param>
        public static void RemoveBuddy(int charId, int buddyId)
        {
            try
            {
                using (IDbConnection conn = Connector.GetConnection())
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("charId", charId);
                    p.Add("buddyId", buddyId);
                    conn.Execute("DELETE FROM `buddylist` WHERE PlayerID = @charId AND BuddyID = @buddyId", p);
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorException(e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="charId">
        /// </param>
        public static void RemovePlayer(int charId)
        {
            try
            {
                using (IDbConnection conn = Connector.GetConnection())
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("charId", charId);
                    conn.Execute("DELETE FROM `buddylist` WHERE PlayerID = @charId OR buddyID = @charId", p);
                }
            }
            catch (Exception e)
            {
                LogUtil.ErrorException(e);
            }
        }

        #endregion
    }
}