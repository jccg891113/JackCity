using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class CList<T> : IList<T>
{
	private int size = 0;
	private T[] buffer;

	public CList ()
	{
	}

	public CList (IEnumerable<T> collection)
	{
		foreach (var item in collection) {
			Add (item);
		}
	}

	#region Interface

	public int Count { get { return size; } }

	public bool IsReadOnly { get { return false; } }

	public void Add (T item)
	{
		if (buffer == null || size == buffer.Length) {
			AllocateMore ();
		}
		buffer [size++] = item;
	}

	public void Clear ()
	{
		size = 0;
	}

	public bool Contains (T item)
	{
		return IndexOf (item) >= 0;
	}

	public void CopyTo (T[] array, int arrayIndex)
	{
		for (int i = 0; i < size; i++) {
			array [arrayIndex + i] = buffer [i];
		}
	}

	public bool Remove (T item)
	{
		if (buffer != null) {
			EqualityComparer<T> comp = EqualityComparer<T>.Default;

			for (int i = 0; i < size; ++i) {
				if (comp.Equals (buffer [i], item)) {
					--size;
					buffer [i] = default(T);
					for (int b = i; b < size; ++b) {
						buffer [b] = buffer [b + 1];
					}
					buffer [size] = default(T);
					return true;
				}
			}
		}
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		if (buffer != null) {
			for (int i = 0; i < size; ++i) {
				yield return buffer [i];
			}
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator ()
	{
		if (buffer != null) {
			for (int i = 0; i < size; ++i) {
				yield return buffer [i];
			}
		}
	}

	public T this [int i] {
		get { return buffer [i]; }
		set { buffer [i] = value; }
	}

	public int IndexOf (T item)
	{
		if (buffer == null) {
			return -1;
		}
		for (int i = 0; i < size; ++i) {
			if (buffer [i].Equals (item)) {
				return i;
			}
		}
		return -1;
	}

	public void Insert (int index, T item)
	{
		if (buffer == null || size == buffer.Length) {
			AllocateMore ();
		}
		if (index > -1 && index < size) {
			for (int i = size; i > index; --i)
				buffer [i] = buffer [i - 1];
			buffer [index] = item;
			++size;
		} else {
			Add (item);
		}
	}

	public void RemoveAt (int index)
	{
		if (buffer != null && index > -1 && index < size) {
			--size;
			buffer [index] = default(T);
			for (int b = index; b < size; ++b) {
				buffer [b] = buffer [b + 1];
			}
			buffer [size] = default(T);
		}
	}

	#endregion

	#region Methods

	public void AddRange (IEnumerable<T> collection)
	{
		foreach (var item in collection) {
			Add (item);
		}
	}

	public T[] ToArray ()
	{
		if (size > 0) {
			if (size < buffer.Length) {
				T[] newList = new T[size];
				for (int i = 0; i < size; ++i) {
					newList [i] = buffer [i];
				}
				return newList;
			}
		}
		return null;
	}

	public void Release ()
	{
		size = 0;
		buffer = null;
	}

	#endregion

	private void AllocateMore ()
	{
		T[] newList = (buffer != null) ? new T[System.Math.Max (buffer.Length << 1, 16)] : new T[16];
		if (buffer != null && size > 0)
			buffer.CopyTo (newList, 0);
		buffer = newList;
	}

	#region Sort About

	[DebuggerHidden]
	[DebuggerStepThrough]
	public void Sort (System.Comparison<T> comparer)
	{
		HeapSort (comparer);
	}

	/// <summary>
	/// 堆排序算法 
	/// </summary>
	/// <param name="length">Length.</param>
	/// <param name="comparer">Comparer.</param>
	private void HeapSort (System.Comparison<T> comparer)
	{  
		//初始堆  
		BuildingHeap (comparer);
		//从最后一个元素开始对序列进行调整  
		for (int i = size - 1; i > 0; --i) {  
			//交换堆顶元素H[0]和堆中最后一个元素  
			T temp = buffer [i];
			buffer [i] = buffer [0];
			buffer [0] = temp;  
			//每次交换堆顶元素和堆中最后一个元素之后，都要对堆进行调整  
			HeapAdjust (0, i, comparer);  
		}  
	}

	/// <summary>
	/// 初始堆进行调整 
	/// 将H[0..length-1]建成堆 
	/// 调整完之后第一个元素是序列的最小的元素 
	/// </summary>
	/// <param name="length">Length.</param>
	/// <param name="comparer">Comparer.</param>
	private void BuildingHeap (System.Comparison<T> comparer)
	{   
		//最后一个有孩子的节点的位置 i=  (length -1) / 2  
		for (int i = (size - 1) / 2; i >= 0; --i) {
			HeapAdjust (i, size, comparer);
		}
	}

	/// <summary>
	/// 已知H[s…m]除了H[s] 外均满足堆的定义
	/// 调整H[s],使其成为大顶堆.即将对第s个结点为根的子树筛选
	/// </summary>
	/// <param name="s">待调整的数组元素的位置.</param>
	/// <param name="length">数组的长度.</param>
	/// <param name="comparer">Comparer.</param>
	private void HeapAdjust (int s, int length, System.Comparison<T> comparer)
	{  
		T tmp = buffer [s];  
		int child = 2 * s + 1; //左孩子结点的位置。(i+1 为当前调整结点的右孩子结点的位置)  
		while (child < length) {  
			if (child + 1 < length && comparer (buffer [child], buffer [child + 1]) < 0) { // 如果右孩子大于左孩子(找到比当前待调整结点大的孩子结点)  
				++child;
			}
			if (comparer (buffer [s], buffer [child]) < 0) {  // 如果较大的子结点大于父结点  
				buffer [s] = buffer [child]; // 那么把较大的子结点往上移动，替换它的父结点  
				s = child;       // 重新设置s ,即待调整的下一个结点的位置  
				child = 2 * s + 1;  
			} else {            // 如果当前待调整结点大于它的左右孩子，则不需要调整，直接退出  
				break;  
			}  
			buffer [s] = tmp;         // 当前待调整的结点放到比其大的孩子结点位置上  
		}
	}

	#endregion
}

