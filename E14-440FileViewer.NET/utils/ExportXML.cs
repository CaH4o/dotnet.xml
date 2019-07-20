using org.tyaa.e14_440fileviewernet.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace E14_440FileViewer.NET.utils
{
    class ExportXML
    {
        //файл трансформации
        private const String STYLESHEET_URI_STRING = "xml-html.xsl";

        public XDocument getChannelsMetadata(ref ChannelsBundle _ChannelsBundle)
        {

            //Корневой узел-элемент
            XElement root = new XElement("bundle");
            //Элемент - коллекция каналов
            XElement channels = new XElement("channels");

            //Число каналов
            int channelsLength = _ChannelsBundle.length();

            //Сколько каналов - столько дочерних элементов
            //добавляем в корневой элемент
            for (int i = 0; i < channelsLength; i++)
            {
                XElement channel = new XElement("channel");
                //Первый дочерний узел в элементе "канал" - атрибут "номер канала"
                channel.SetAttributeValue("number", _ChannelsBundle.numbersArray[i]);
                //Второй дочерний узел в элементе "канал" - элемент "усиление канала"
                XElement amp = new XElement("amplification");
                amp.Add(_ChannelsBundle.ampsArray[i]);
                channel.Add(amp);
                // Определяем максимальное значение амплитуды сигнала из i-го канала,
                //заворачиваем в узел-элемент
                //и присоединяем его к текущему формируемому узлу channel
                XElement max = new XElement("max");
                max.Add(_ChannelsBundle[i].dataArrayList.ToArray().Max());
                channel.Add(max);
				// Определяем минимальное значение амплитуды сигнала из i-го канала,
				//заворачиваем в узел-элемент
				//и присоединяем его к текущему формируемому узлу channel
				XElement min = new XElement("min");
				min.Add(_ChannelsBundle[i].dataArrayList.ToArray().Min());
				channel.Add(min);
				//Добавляем элемент "канал" в элемент-коллекцию каналов
				channels.Add(channel);
            }

            //Создаем узел-элемент с информацией о частоте            
            XElement frequency = new XElement("frequency");
            frequency.Add(_ChannelsBundle.frequency);

            //...и добавляем его корню
            root.Add(frequency);
            //также в корень добавляем элемент-коллекцию элементов каналов
            root.Add(channels);

            //Создаем и возвращаем объект xml-документа с заголовком и корневым элементом
            return new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
        }

        public void saveChannelsMetadata(ref ChannelsBundle _ChannelsBundle, ReportTypes _reportType)
        {
            XDocument xdoc = getChannelsMetadata(ref _ChannelsBundle);
            switch (_reportType)
            {
                case ReportTypes.JSON:
                    break;
                case ReportTypes.XML:
                    //Сохраняем xml-документ в файл
                    xdoc.Save("ChannelsMetadata.xml");
                    break;
                case ReportTypes.HTML:
                    //создаем объект файла стилей xsl
                    XslCompiledTransform xslt = new XslCompiledTransform();
                    //заполняем его из файла
                    xslt.Load(STYLESHEET_URI_STRING);
                    //создаем обект записи, указываем ему имя выходного файла
                    XmlTextWriter xmlTextWriter = new XmlTextWriter("ChannelsMetadata.html", null);
                    //устанавливаем сохранение форматирования
                    xmlTextWriter.Formatting = Formatting.Indented;
                    //запускаем трансформацию с выводом в файл, который можно будет открыть в MS Word
                    using (var xmlReader = xdoc.CreateReader())
                    {
                        xslt.Transform(xmlReader, xmlTextWriter);
                    }
                    Console.WriteLine("An HTML file was Received!");
                    break;
                default:
                    break;
            }
        }
    }
}
