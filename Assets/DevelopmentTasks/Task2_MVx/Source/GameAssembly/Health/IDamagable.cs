using System.Collections;
using System.Collections.Generic;

namespace MVxTask.Health
{
    public interface IDamagable
    {
        event System.Action<float> OnDamaged;

        void Damage(float damage);
    }
}
