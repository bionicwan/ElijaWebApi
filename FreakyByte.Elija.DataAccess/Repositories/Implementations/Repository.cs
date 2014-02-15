namespace FreakyByte.Elija.DataAccess.Repositories.Implementations
{
    using System;
    using System.Data;
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;

    using FreakyByte.Elija.DataAccess.Model;
    using FreakyByte.Elija.DataAccess.Repositories.Interfaces;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        /// <value>
        ///     The context.
        /// </value>
        public ElijaEntities Context { get; set; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="context"></param>
        public Repository(ElijaEntities context)
        {
            this.Context = context;
        }

        #endregion

        #region Public Properties




        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The add.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Add(T entity)
        {
            this.Context.CreateObjectSet<T>().AddObject(entity);
        }

        /// <summary>
        ///     The count.
        /// </summary>
        /// <returns>
        ///     The <see cref="int" />.
        /// </returns>
        public int Count()
        {
            return this.Context.CreateObjectSet<T>().Count<T>();
        }

        /// <summary>
        ///     The delete.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Delete(T entity)
        {
            this.Context.CreateObjectSet<T>().DeleteObject(entity);
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }

        /// <summary>
        ///     The find all by.
        /// </summary>
        /// <param name="predicate">
        ///     The predicate.
        /// </param>
        /// <param name="include">
        ///     The include.
        /// </param>
        /// <returns>
        ///     The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<T> FindAllBy(Expression<Func<T, bool>> predicate, string[] include)
        {
            ObjectSet<T> objset = this.Context.CreateObjectSet<T>();
            var query = objset as ObjectQuery<T>;
            if (include != null)
            {
                query = include.Aggregate(query, (current, navprop) => current.Include(navprop));
            }

            return query.Where(predicate).AsQueryable();
        }

        /// <summary>
        ///     The find first by.
        /// </summary>
        /// <param name="predicate">
        ///     The predicate.
        /// </param>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public T FindFirstBy(Expression<Func<T, bool>> predicate)
        {
            return this.Context.CreateObjectSet<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<T> GetAll()
        {
            return this.Context.CreateObjectSet<T>().AsQueryable<T>();
        }

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <param name="include">
        ///     The include.
        /// </param>
        /// <returns>
        ///     The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<T> GetAll(string[] include)
        {
            ObjectSet<T> objset = this.Context.CreateObjectSet<T>();
            var query = objset as ObjectQuery<T>;
            if (include != null)
            {
                query = include.Aggregate(query, (current, navprop) => current.Include(navprop));
            }

            return query.AsQueryable();
        }

        /// <summary>
        ///     The max entity.
        /// </summary>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public T MaxEntity()
        {
            try
            {
                return this.Context.CreateObjectSet<T>().ToList().Last();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     The refresh.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Refresh(T entity)
        {
            this.Context.Refresh(RefreshMode.StoreWins, entity);
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Update(T entity)
        {
            this.Context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        #endregion
    }
}