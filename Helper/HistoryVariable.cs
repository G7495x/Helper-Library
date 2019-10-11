/// <see href="https://github.com/G7495x/Helper-Library">Up-to-date code here.</see>
using System;

/// <summary>
/// HistoryVariable is a variable that can store past values.
/// Internally uses fixed-size queues.
/// By default, creates a variable that can store 2 values (1 current + 1 previous).
/// </summary>
public class HistoryVariable<T>{

	private T[] data;
	private int top=0;

	public HistoryVariable(){ data=new T[2]; }

	/// <summary>Creates a HistoryVariable with a specific number of values to preserve (Min=2).</summary>
	/// <param name="length">Number of values to preserve (Min=2).</param>
	public HistoryVariable(int length){
		if(length<2) throw new IndexOutOfRangeException("Length of HistoryVariable(s) must be >=2. Found "+length+".");
		data=new T[length];
	}

	/// <returns>The number of values preserved in the HistoryVariable.</returns>
	public int Length{ get{ return data.Length; }}

	/// <summary>Set the value of HistoryVariable.</summary>
	/// <param name="value">Value to set.</param>
	/// <returns>Back the current value of the HistoryVariable.</returns>
	public T push(T value){
		top=++top%data.Length;
		return data[top]=value;
	}

	/// <summary>Get the current/past value of the HistoryVariable.</summary>
	/// <param name="index">Index of the history (0=Current value,-1=Previous value,-2=Previous to previous value).</param>
	/// <returns>nth past value of the HistoryVariable.</returns>
	/// <example>
	/// historyVariable[ 0] gives the current value
	/// historyVariable[-1] gives the previous value
	/// historyVariable[-2] gives the previous to the previous value
	/// </example>
	public T this[int index]{
		get{
			if(index>0) throw new IndexOutOfRangeException("Index for HistoryVariable(s) must be <0. Found "+index+".");
			if(index==0) return data[top];
			return data[(data.Length-(-index%data.Length))%data.Length];
		}
	}
}
