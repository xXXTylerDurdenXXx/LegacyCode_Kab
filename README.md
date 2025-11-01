# DateUtil — утилиты для работы с датами

## Описание
Набор утилит для парсинга, форматирования и вычислений с датами в форматах `dd/MM/yyyy` и `MM/dd/yyyy`.

## Интерфейс
Публичный интерфейс: `IDateUtil` (см. `Utils/DateUtil.cs`).

Ключевые методы:
- `TryParseDdMmYyyy(string input, out DateTime date)`
- `TryParseMmDdYyyy(string input, out DateTime date)`
- `TryConvert(string input, DateFormat source, out string result)`
- `TryGetDayOfWeek(string input, out DayOfWeek dayOfWeek)`
- `TryGetDaysDifference(string d1, string d2, out int days)`
- `TryAddDays(string input, int n, out string result)`

## Как запускать и тестировать
- Открыть проект в Visual Studio / `dotnet` CLI.
- Запустить тесты: `dotnet test` (если добавлены тесты).

## Замечания / ограничения
- Валидация ограничивает года диапазоном `1900..2100`.
- Форматы дат строгие; используется `CultureInfo.InvariantCulture`.

## План рефакторинга (коротко)
1. Вынести парсинг в `TryParse`.
2. Перейти на `Try`-паттерн вместо строковых кодов ошибок.
3. Добавить модульные тесты.
4. Внедрить интерфейсы и разделить ответственность.