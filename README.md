# CollectionBookWPFandMVVM
Написать программу для ведения коллекции книг с применением архитектурного паттерна MVVM по технологии WPF.
Коллекция представлена списком, где каждый элемент содержит информацию о книге: автор, название, тематика, год издания. Элемент украшен рамкой с закругленными углами. 
Тематика должна быть представлена перечислением (перечисление имеет фиксированный набор тематик), год издания целым числом, остальные данные имеют строковый формат. Для автора и года издания предусмотреть проверку на ввод корректного значения.
Предоставить функционал по добавлению, удалению и редактированию данных о книгах. Для этого предусмотреть отдельную форму, появляющуюся поверх основного окна программы. Пользователь должен иметь возможность отсортировать представленную информацию по автору и году издания.
Для хранения информации использовать локальную базу данных с применением технологий ADO.Net или Entity Framework. Важно предусмотреть некоторый уровень абстракции от конкретной системы хранения. Т.е. построить такую архитектуру, при которой будет также возможно сохранение в текстовый файл, XML, JSON и т.д. через расширение кода. Непосредственно функционал будет реализовываться в следующей итерации.
Желательно применение стилей, словарей ресурсов, шаблонов.
