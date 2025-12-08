using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    using Ninject;
    using System;

    namespace BusinessLogic
    {
        /// <summary>
        /// Сервис для работы с IoC контейнером Ninject
        /// </summary>
        public static class NinjectService
        {
            private static IKernel _kernel;

            /// <summary>
            /// Инициализирует ядро Ninject
            /// </summary>
            public static void Initialize()
            {
                _kernel = new StandardKernel(new NinjectModule());
            }

            /// <summary>
            /// Получает экземпляр сервиса
            /// </summary>
            public static T Get<T>()
            {
                if (_kernel == null)
                    throw new InvalidOperationException("Ninject kernel not initialized. Call Initialize() first.");

                return _kernel.Get<T>();
            }

            /// <summary>
            /// Освобождает ресурсы
            /// </summary>
            public static void Dispose()
            {
                _kernel?.Dispose();
            }
        }
    }
}
