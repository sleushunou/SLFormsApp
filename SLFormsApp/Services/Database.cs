using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLFormsApp.Models;
using Softeq.XToolkit.Common.Extensions;
using SQLite;

namespace SLFormsApp.Services
{
    public class Database
    {
        private static readonly Lazy<SQLiteAsyncConnection> _lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Defines.DatabasePath, Defines.Flags);
        });

        private static SQLiteAsyncConnection DB => _lazyInitializer.Value;

        private static bool initialized = false;

        public Database()
        {
            InitializeAsync().FireAndForget();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            return await DB.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(string login)
        {
            return DB.Table<User>().FirstOrDefaultAsync(i => i.Login == login);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                var result = await DB.InsertAsync(user)
                    .ConfigureAwait(false);
                return result == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            try
            {
                await Task.Delay(1000).ConfigureAwait(false);

                var result = await DB.DeleteAsync(user)
                    .ConfigureAwait(false);
                return result == 1;
            }
            catch
            {
                return false;
            }
        }

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!DB.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await DB.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
    }
}
