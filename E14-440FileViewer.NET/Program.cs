using E14_440FileViewer.NET.dao;
using E14_440FileViewer.NET.model.interfaces;
using E14_440FileViewer.NET.viewcontroller.utils;
using Moq;
using org.tyaa.e14_440fileviewernet.model;
using gen = org.tyaa.e14_440fileviewernet.model.generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E14_440FileViewer.NET.utils;
using E14_440FileViewer.NET.dao.implements.NewDataFileDAO_Parts;

namespace org.tyaa.e14_440fileviewernet
{
    class Program
    {
        static void Main(string[] args)
        {
			//Channel channel1 = new Channel(1, 0);
			//Channel channel2 = new Channel(2, 0);

			//channel1.addDataItem(0);
			//channel1.addDataItem(1.01);
			//channel1.addDataItem(1.02);
			//channel1.addDataItem(1.03);

			//foreach (double dataItem in channel1.getDataArray())
			//{
			//	Console.WriteLine(dataItem);
			//}

			//ChannelsBundle ChannelsBundle1 = new ChannelsBundle(null, null, 1500);

			//channel2.addDataItem(0.001);
			//channel2.addDataItem(1.015);
			//channel2.addDataItem(1.025);
			//channel2.addDataItem(1.035);

			//ChannelsBundle1[0] = channel1;
			//ChannelsBundle1[1] = channel2;

			//foreach (Channel channel in ChannelsBundle1)
			//{
			//	foreach (double dataItem in channel.getDataArray())
			//	{
			//		Console.WriteLine(dataItem);
			//	}
			//}

			//Filters filters1 = Filters.Batterwort;
			//Filters filters2 = Filters.Chebishev;
			//Console.WriteLine(filters1 < filters2);

			//DataFileFacade dataFileFacade = new DataFileFacade(DataFileTypes.OldDataFile);
			//dataFileFacade.getChannels();
			//dataFileFacade.setDAOType(DataFileTypes.NewDataFile);
			//dataFileFacade.getChannels();
			//dataFileFacade.setDAOType(DataFileTypes.OldDataFile);
			//dataFileFacade.getChannels();

			//Mock<IChannelsBundle> mock = new Mock<IChannelsBundle>();
			//mock.Setup(m => m.channelArray).Returns(
			//	new Channel[]{
			//        //new Channel{dataArray = new double?[3]{1, 2, 3}}
			//        //,new Channel{dataArray = new double?[3]{0, 1, 2}}
			//        new Channel{dataArrayList = (new ArrayList(){1, 2, 3})}
			//		,new Channel{dataArrayList = new ArrayList(){0, 1, 2}}
			//	}
			//);
			//foreach (Channel channel in mock.Object.channelArray.AsEnumerable())
			//{
			//	foreach (double dataItem in channel.getDataArray())
			//	{
			//		Console.WriteLine(dataItem);
			//	}
			//}

			//const Int32 count = 10000000;

			//using (new OperationProfiler("Channel<T>"))
			//{
			//	gen.Channel<double> channel1 = new gen.Channel<double>(1, 0);
			//	for (Int32 n = 0; n < count; n++)
			//	{
			//		channel1.addDataItem(n);
			//	}
			//	channel1 = null;  // для гарантированного выполнения сборки мусора
			//}

			//using (new OperationProfiler("Channel"))
			//{
			//	Channel channel1 = new Channel(1, 0);
			//	for (Int32 n = 0; n < count; n++)
			//	{
			//		channel1.addDataItem(n);
			//	}
			//}

			//gen.Channel<double> channel1 = new gen.Channel<double>(1, 0);


			//Channel channel2 = new Channel();
			//channel2 = null;

			/*Чтение бинарных файлов*/

			/*String filePath = @"D:/Temp/10f";

            ParamsReader paramsReader = new ParamsReader();
            List<gen.Channel<double>> channelsArrayList =
                paramsReader.getParams(filePath + ".prm");
            Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
            foreach (gen.Channel<double> channel in channelsArrayList)
            {
                Console.WriteLine(channel.number + " " + channel.amp);
            }*/

			//DataReader dataReader = new DataReader();
			//dataReader.getData(@"D:/Temp/10f" + ".dat", ref channelsArrayList);
			//foreach (double dataItem in channelsArrayList[1].getDataArray())
			//{
			//	Console.WriteLine(dataItem);
			//}

			//*Запись метаданных в XML-файл*/

			Channel channel1 = new Channel(1, 0);
			Channel channel2 = new Channel(2, 0);

			channel1.addDataItem(0);
			channel1.addDataItem(1.01);
			channel1.addDataItem(1.02);
			channel1.addDataItem(1.03);
			channel1.addDataItem(1.51);
			channel1.addDataItem(1.22);
			channel1.addDataItem(1.03);

			channel2.addDataItem(0.001);
			channel2.addDataItem(1.015);
			channel2.addDataItem(1.025);
			channel2.addDataItem(1.035);
			channel2.addDataItem(1.115);
			channel2.addDataItem(1.095);
			channel2.addDataItem(1.035);

			int[] numbersArray = new int[] { channel1.number, channel2.number };
			int[] ampsArray = new int[] { channel1.amp, channel2.amp };

			ChannelsBundle ChannelsBundle1 = new ChannelsBundle(numbersArray, ampsArray, 1500);

			ChannelsBundle1[0] = channel1;
			ChannelsBundle1[1] = channel2;

			ExportXML exportXML = new ExportXML();
			exportXML.saveChannelsMetadata(ref ChannelsBundle1, ReportTypes.XML);




			ImportXML importXML = new ImportXML();
			ChannelsBundle ChannelsBundle2 =
				importXML.getChannelsMetadata(@"ChannelsMetadata.xml");

			Console.WriteLine("frequency = {0}", ChannelsBundle2.frequency);

			foreach (Channel channel in ChannelsBundle2)
			{
				Console.WriteLine("number = {0}; amplification = {1}", channel.number, channel.amp);
			}

			Console.ReadLine();


 /*Чтение бинарных файлов C++*/

            /*String filePath = @"D:/Temp/10f";

            ParamsReader paramsReader = new ParamsReader();
            List<gen.Channel<double>> channelsArrayList =
                paramsReader.getParams(filePath + ".prm");
            Console.WriteLine(paramsReader.Count + " " + paramsReader.Frequency + "\n");
            foreach (gen.Channel<double> channel in channelsArrayList)
            {
                Console.WriteLine(channel.number + " " + channel.amp);
            }*/
        }
    }
}
