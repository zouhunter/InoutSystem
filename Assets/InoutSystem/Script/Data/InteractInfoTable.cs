// This code automatically generated by TableCodeGen
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractInfoTable : CsvTable
{
    [System.Serializable]
	public class Row
	{
		public int nodeID;
		public string inType;
		public string outType;
		public string information;
		public string action;
		public string outFailInformation;
		public string outFailAction;

	}

	List<Row> rowList = new List<Row>();

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public override void Load(string csvData)
	{
		rowList.Clear();
		grid = ParserCSV.Parse(csvData);
		for(int i = 1 ; i < grid.Length ; i++)
		{
			Row row = new Row();
			row.nodeID = int.Parse(grid[i][0]);
			row.inType = grid[i][1];
			row.outType = grid[i][2];
			row.information = grid[i][3];
			row.action = grid[i][4];
			row.outFailInformation = grid[i][5];
			row.outFailAction = grid[i][6];

			rowList.Add(row);
		}
		isLoaded = true;
	}
    public override string UnLoad()
    {
        WhileNull();
        for (int i = 1; i < rowList.Count + 1; i++)
        {
            Row row = rowList[i-1];
			grid[i][0] = row.nodeID.ToString();
			grid[i][1] = row.inType;
			grid[i][2] = row.outType;
			grid[i][3] = row.information;
			grid[i][4] = row.action;
			grid[i][5] = row.outFailInformation;
			grid[i][6] = row.outFailAction;

        }
       return UParserCSV.UParser(grid);
    }
    private void WhileNull()
    {
        //if (grid == null)
        //{
            grid = new string[rowList.Count + 1][];
			if (grid[0] == null) grid[0] = new string[7];
			grid[0][0] = "nodeID";
			grid[0][1] = "inType";
			grid[0][2] = "outType";
			grid[0][3] = "information";
			grid[0][4] = "action";
			grid[0][5] = "outFailInformation";
			grid[0][6] = "outFailAction";

        //}

        for (int i = 1; i<rowList.Count + 1; i++)
        {
			if (grid[i] == null) grid[i] = new string[7];
        }
    }

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if(rowList.Count <= i)
			return null;
		return rowList[i];
	}

	public Row Find_nodeID(string find)
	{
		return rowList.Find(x => x.nodeID.ToString() == find);
	}
	public List<Row> FindAll_nodeID(string find)
	{
		return rowList.FindAll(x => x.nodeID.ToString() == find);
	}
	public Row Find_inType(string find)
	{
		return rowList.Find(x => x.inType == find);
	}
	public List<Row> FindAll_inType(string find)
	{
		return rowList.FindAll(x => x.inType == find);
	}
	public Row Find_outType(string find)
	{
		return rowList.Find(x => x.outType == find);
	}
	public List<Row> FindAll_outType(string find)
	{
		return rowList.FindAll(x => x.outType == find);
	}
	public Row Find_information(string find)
	{
		return rowList.Find(x => x.information == find);
	}
	public List<Row> FindAll_information(string find)
	{
		return rowList.FindAll(x => x.information == find);
	}
	public Row Find_action(string find)
	{
		return rowList.Find(x => x.action == find);
	}
	public List<Row> FindAll_action(string find)
	{
		return rowList.FindAll(x => x.action == find);
	}
	public Row Find_outFailInformation(string find)
	{
		return rowList.Find(x => x.outFailInformation == find);
	}
	public List<Row> FindAll_outFailInformation(string find)
	{
		return rowList.FindAll(x => x.outFailInformation == find);
	}
	public Row Find_outFailAction(string find)
	{
		return rowList.Find(x => x.outFailAction == find);
	}
	public List<Row> FindAll_outFailAction(string find)
	{
		return rowList.FindAll(x => x.outFailAction == find);
	}

}