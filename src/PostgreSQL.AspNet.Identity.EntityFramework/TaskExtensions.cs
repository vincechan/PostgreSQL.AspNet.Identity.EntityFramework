namespace PostgreSQL.AspNet.Identity.EntityFramework {

	using System;
	using System.Runtime.CompilerServices;
	using System.Threading;
	using System.Threading.Tasks;

	internal static class TaskExtensions {

		public static CultureAwaiter<T> WithCurrentCulture<T>(this Task<T> task) {
			return new CultureAwaiter<T>(task);
		}

		public static CultureAwaiter WithCurrentCulture(this Task task) {
			return new CultureAwaiter(task);
		}

		public struct CultureAwaiter<T> : ICriticalNotifyCompletion {
			private readonly Task<T> _task;

			public CultureAwaiter(Task<T> task) {
				_task = task;
			}

			public bool IsCompleted {
				get { return _task.IsCompleted; }
			}

			public CultureAwaiter<T> GetAwaiter() {
				return this;
			}

			public T GetResult() {
				return _task.GetAwaiter().GetResult();
			}

			public void OnCompleted(Action continuation) {

				// The compiler will never call this method
				throw new NotImplementedException();
			}

			public void UnsafeOnCompleted(Action continuation) {
				var currentCulture = Thread.CurrentThread.CurrentCulture;
				var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
				_task.ConfigureAwait(false).GetAwaiter().UnsafeOnCompleted(() => {
					var originalCulture = Thread.CurrentThread.CurrentCulture;
					var originalUiCulture = Thread.CurrentThread.CurrentUICulture;
					Thread.CurrentThread.CurrentCulture = currentCulture;
					Thread.CurrentThread.CurrentUICulture = currentUiCulture;
					try {
						continuation();
					}
					finally {
						Thread.CurrentThread.CurrentCulture = originalCulture;
						Thread.CurrentThread.CurrentUICulture = originalUiCulture;
					}
				});
			}
		}

		public struct CultureAwaiter : ICriticalNotifyCompletion {
			private readonly Task _task;

			public CultureAwaiter(Task task) {
				_task = task;
			}

			public bool IsCompleted {
				get { return _task.IsCompleted; }
			}

			public CultureAwaiter GetAwaiter() {
				return this;
			}

			public void GetResult() {
				_task.GetAwaiter().GetResult();
			}

			public void OnCompleted(Action continuation) {

				// The compiler will never call this method
				throw new NotImplementedException();
			}

			public void UnsafeOnCompleted(Action continuation) {
				var currentCulture = Thread.CurrentThread.CurrentCulture;
				var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
				_task.ConfigureAwait(false).GetAwaiter().UnsafeOnCompleted(() => {
					var originalCulture = Thread.CurrentThread.CurrentCulture;
					var originalUiCulture = Thread.CurrentThread.CurrentUICulture;
					Thread.CurrentThread.CurrentCulture = currentCulture;
					Thread.CurrentThread.CurrentUICulture = currentUiCulture;
					try {
						continuation();
					}
					finally {
						Thread.CurrentThread.CurrentCulture = originalCulture;
						Thread.CurrentThread.CurrentUICulture = originalUiCulture;
					}
				});
			}
		}
	}
}
