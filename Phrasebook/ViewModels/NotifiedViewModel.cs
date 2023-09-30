using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Phrasebook.ViewModels;

/// <summary>
/// Модель представления с методами для привязки данных.
/// </summary>
internal class NotifiedViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Меняет значение свойства и оповещает об этом событии.
    /// </summary>
    /// <typeparam name="T">Тип свойства.</typeparam>
    /// <param name="field">Ссылка на заднее поле.</param>
    /// <param name="value">Новое значение.</param>
    /// <param name="name">
    ///     <para>Название свойства.</para>
    ///     <para>
    ///     Если вызов метода происходит внутри того же свойства, для которого и обновляется значение,
    ///     то нет необходимости указывать <paramref name="name"/> - название свойства будет передано автоматически.
    ///     </para>    
    /// </param>
    /// <returns></returns>
    protected bool ChangeProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (!Equals(field, value))
        {
            field = value;
            OnPropertyChanged(name);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Уведомляет клиентов об изменении свойства.
    /// </summary>
    /// <param name="name">
    ///     <para>Название свойства.</para>
    ///     <para>
    ///     Если вызов метода происходит внутри того же свойства, для которого и обновляется значение,
    ///     то нет необходимости указывать <paramref name="name"/> - название свойства будет передано автоматически.
    ///     </para>    
    /// </param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
