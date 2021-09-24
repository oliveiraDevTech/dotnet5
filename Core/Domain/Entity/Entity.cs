using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;

namespace Core.Domain.Entity
{
    public abstract class Entity<TId> : Notifiable<Notification>, IEquatable<Entity<TId>>
    {
        protected Entity()
        {
        }

        protected Entity(TId id) => Id = id;

        public virtual TId Id { get; protected set; }
        //public virtual ICollection<INotification> Events { get; private set; }

        //public virtual void AddEvent<T>(T args) where T : INotification
        //{
        //    Events = Events ?? new List<INotification>();
        //    Events.Add(args);
        //}

        //public virtual void RemoveEvent<T>(T args) where T : INotification
        //{
        //    Events?.Remove(args);
        //}

        public virtual bool Equals(Entity<TId> other) => this.Equals(other);

        public virtual void PublishEvents()
        {
        }

        public virtual void IsValidation()
        {
        }

        protected virtual void OnIdChanged()
        {
        }

        public virtual void ModifyByEntity(Entity<TId> entityModify)
        {
            foreach (var property in this.GetType().GetProperties())
            {
                if (property.Name != Id.GetType().Name
                    && property.Name != Id.GetType().Name)
                {
                    var valueModify = entityModify.GetType().GetProperty(property.Name).GetValue(entityModify);

                    if (!property.GetValue(this).Equals(valueModify))
                    {
                        property.SetValue(this, valueModify);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}