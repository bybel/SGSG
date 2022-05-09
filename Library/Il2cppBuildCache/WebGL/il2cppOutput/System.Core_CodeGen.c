#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::ArgumentOutOfRange(System.String)
extern void Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2 (void);
// 0x00000003 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000004 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000005 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000006 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000007 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000008 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000009 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000A System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000B TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000C System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000E TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000010 TSource System.Linq.Enumerable::ElementAt(System.Collections.Generic.IEnumerable`1<TSource>,System.Int32)
// 0x00000011 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000012 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000013 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000014 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000015 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000016 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000017 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000018 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000019 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x0000001A System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x0000001B System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x0000001C System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000001D System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000001E System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x0000001F System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000020 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x00000021 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000022 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000023 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000024 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000025 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000026 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000027 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000028 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000029 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x0000002A System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002B System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002C System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000002D System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x0000002E System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x0000002F System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000030 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000031 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000032 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000033 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000034 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000035 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000036 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000037 System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000038 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000039 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x0000003A System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003B System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003C System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003D System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x0000003E System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x0000003F System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000040 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000041 System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000042 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000043 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000044 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000045 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000046 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x00000047 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000048 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000049 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000004A System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x0000004B System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x0000004C System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x0000004D System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x0000004E TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x0000004F System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x00000050 System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000051 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000052 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000053 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000054 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000055 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x00000056 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x00000057 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x00000058 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000059 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x0000005A System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x0000005B System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x0000005C TElement[] System.Linq.Buffer`1::ToArray()
// 0x0000005D System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x0000005E System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x0000005F System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000060 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000061 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000062 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x00000063 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x00000064 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x00000065 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x00000066 System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x00000067 System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x00000068 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x00000069 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000006A System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000006B System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x0000006C System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x0000006D System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x0000006E System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x0000006F System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x00000070 System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000071 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000072 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x00000073 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x00000074 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x00000075 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x00000076 System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x00000077 T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x00000078 System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x00000079 System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[121] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_ArgumentOutOfRange_m2EFB999454161A6B48F8DAC3753FDC190538F0F2,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[121] = 
{
	2303,
	2303,
	2389,
	2389,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[41] = 
{
	{ 0x02000004, { 65, 4 } },
	{ 0x02000005, { 69, 9 } },
	{ 0x02000006, { 80, 7 } },
	{ 0x02000007, { 89, 10 } },
	{ 0x02000008, { 101, 11 } },
	{ 0x02000009, { 115, 9 } },
	{ 0x0200000A, { 127, 12 } },
	{ 0x0200000B, { 142, 1 } },
	{ 0x0200000C, { 143, 2 } },
	{ 0x0200000E, { 145, 3 } },
	{ 0x0200000F, { 150, 5 } },
	{ 0x02000010, { 155, 7 } },
	{ 0x02000011, { 162, 3 } },
	{ 0x02000012, { 165, 7 } },
	{ 0x02000013, { 172, 4 } },
	{ 0x02000014, { 176, 21 } },
	{ 0x02000016, { 197, 2 } },
	{ 0x06000005, { 0, 10 } },
	{ 0x06000006, { 10, 10 } },
	{ 0x06000007, { 20, 5 } },
	{ 0x06000008, { 25, 5 } },
	{ 0x06000009, { 30, 2 } },
	{ 0x0600000A, { 32, 1 } },
	{ 0x0600000B, { 33, 3 } },
	{ 0x0600000C, { 36, 2 } },
	{ 0x0600000D, { 38, 4 } },
	{ 0x0600000E, { 42, 4 } },
	{ 0x0600000F, { 46, 3 } },
	{ 0x06000010, { 49, 3 } },
	{ 0x06000011, { 52, 1 } },
	{ 0x06000012, { 53, 3 } },
	{ 0x06000013, { 56, 2 } },
	{ 0x06000014, { 58, 2 } },
	{ 0x06000015, { 60, 5 } },
	{ 0x06000025, { 78, 2 } },
	{ 0x0600002A, { 87, 2 } },
	{ 0x0600002F, { 99, 2 } },
	{ 0x06000035, { 112, 3 } },
	{ 0x0600003A, { 124, 3 } },
	{ 0x0600003F, { 139, 3 } },
	{ 0x06000049, { 148, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[199] = 
{
	{ (Il2CppRGCTXDataType)2, 1209 },
	{ (Il2CppRGCTXDataType)3, 4076 },
	{ (Il2CppRGCTXDataType)2, 2021 },
	{ (Il2CppRGCTXDataType)2, 1705 },
	{ (Il2CppRGCTXDataType)3, 6970 },
	{ (Il2CppRGCTXDataType)2, 1289 },
	{ (Il2CppRGCTXDataType)2, 1712 },
	{ (Il2CppRGCTXDataType)3, 6988 },
	{ (Il2CppRGCTXDataType)2, 1707 },
	{ (Il2CppRGCTXDataType)3, 6977 },
	{ (Il2CppRGCTXDataType)2, 1210 },
	{ (Il2CppRGCTXDataType)3, 4077 },
	{ (Il2CppRGCTXDataType)2, 2044 },
	{ (Il2CppRGCTXDataType)2, 1714 },
	{ (Il2CppRGCTXDataType)3, 6995 },
	{ (Il2CppRGCTXDataType)2, 1306 },
	{ (Il2CppRGCTXDataType)2, 1722 },
	{ (Il2CppRGCTXDataType)3, 7025 },
	{ (Il2CppRGCTXDataType)2, 1718 },
	{ (Il2CppRGCTXDataType)3, 7009 },
	{ (Il2CppRGCTXDataType)2, 427 },
	{ (Il2CppRGCTXDataType)3, 19 },
	{ (Il2CppRGCTXDataType)3, 20 },
	{ (Il2CppRGCTXDataType)2, 773 },
	{ (Il2CppRGCTXDataType)3, 2976 },
	{ (Il2CppRGCTXDataType)2, 428 },
	{ (Il2CppRGCTXDataType)3, 23 },
	{ (Il2CppRGCTXDataType)3, 24 },
	{ (Il2CppRGCTXDataType)2, 779 },
	{ (Il2CppRGCTXDataType)3, 2978 },
	{ (Il2CppRGCTXDataType)2, 1525 },
	{ (Il2CppRGCTXDataType)3, 6054 },
	{ (Il2CppRGCTXDataType)3, 3313 },
	{ (Il2CppRGCTXDataType)2, 478 },
	{ (Il2CppRGCTXDataType)3, 447 },
	{ (Il2CppRGCTXDataType)3, 448 },
	{ (Il2CppRGCTXDataType)2, 1290 },
	{ (Il2CppRGCTXDataType)3, 4389 },
	{ (Il2CppRGCTXDataType)2, 1153 },
	{ (Il2CppRGCTXDataType)2, 878 },
	{ (Il2CppRGCTXDataType)2, 960 },
	{ (Il2CppRGCTXDataType)2, 1021 },
	{ (Il2CppRGCTXDataType)2, 1154 },
	{ (Il2CppRGCTXDataType)2, 879 },
	{ (Il2CppRGCTXDataType)2, 961 },
	{ (Il2CppRGCTXDataType)2, 1022 },
	{ (Il2CppRGCTXDataType)2, 962 },
	{ (Il2CppRGCTXDataType)2, 1023 },
	{ (Il2CppRGCTXDataType)3, 2977 },
	{ (Il2CppRGCTXDataType)2, 1152 },
	{ (Il2CppRGCTXDataType)2, 959 },
	{ (Il2CppRGCTXDataType)2, 1020 },
	{ (Il2CppRGCTXDataType)2, 952 },
	{ (Il2CppRGCTXDataType)2, 953 },
	{ (Il2CppRGCTXDataType)2, 1018 },
	{ (Il2CppRGCTXDataType)3, 2975 },
	{ (Il2CppRGCTXDataType)2, 877 },
	{ (Il2CppRGCTXDataType)2, 958 },
	{ (Il2CppRGCTXDataType)2, 876 },
	{ (Il2CppRGCTXDataType)3, 8443 },
	{ (Il2CppRGCTXDataType)3, 2630 },
	{ (Il2CppRGCTXDataType)2, 686 },
	{ (Il2CppRGCTXDataType)2, 955 },
	{ (Il2CppRGCTXDataType)2, 1019 },
	{ (Il2CppRGCTXDataType)2, 1068 },
	{ (Il2CppRGCTXDataType)3, 4078 },
	{ (Il2CppRGCTXDataType)3, 4080 },
	{ (Il2CppRGCTXDataType)2, 301 },
	{ (Il2CppRGCTXDataType)3, 4079 },
	{ (Il2CppRGCTXDataType)3, 4088 },
	{ (Il2CppRGCTXDataType)2, 1213 },
	{ (Il2CppRGCTXDataType)2, 1708 },
	{ (Il2CppRGCTXDataType)3, 6978 },
	{ (Il2CppRGCTXDataType)3, 4089 },
	{ (Il2CppRGCTXDataType)2, 993 },
	{ (Il2CppRGCTXDataType)2, 1040 },
	{ (Il2CppRGCTXDataType)3, 2984 },
	{ (Il2CppRGCTXDataType)3, 8433 },
	{ (Il2CppRGCTXDataType)2, 1719 },
	{ (Il2CppRGCTXDataType)3, 7010 },
	{ (Il2CppRGCTXDataType)3, 4081 },
	{ (Il2CppRGCTXDataType)2, 1212 },
	{ (Il2CppRGCTXDataType)2, 1706 },
	{ (Il2CppRGCTXDataType)3, 6971 },
	{ (Il2CppRGCTXDataType)3, 2983 },
	{ (Il2CppRGCTXDataType)3, 4082 },
	{ (Il2CppRGCTXDataType)3, 8432 },
	{ (Il2CppRGCTXDataType)2, 1715 },
	{ (Il2CppRGCTXDataType)3, 6996 },
	{ (Il2CppRGCTXDataType)3, 4095 },
	{ (Il2CppRGCTXDataType)2, 1214 },
	{ (Il2CppRGCTXDataType)2, 1713 },
	{ (Il2CppRGCTXDataType)3, 6989 },
	{ (Il2CppRGCTXDataType)3, 4430 },
	{ (Il2CppRGCTXDataType)3, 2199 },
	{ (Il2CppRGCTXDataType)3, 2985 },
	{ (Il2CppRGCTXDataType)3, 2198 },
	{ (Il2CppRGCTXDataType)3, 4096 },
	{ (Il2CppRGCTXDataType)3, 8434 },
	{ (Il2CppRGCTXDataType)2, 1723 },
	{ (Il2CppRGCTXDataType)3, 7026 },
	{ (Il2CppRGCTXDataType)3, 4109 },
	{ (Il2CppRGCTXDataType)2, 1216 },
	{ (Il2CppRGCTXDataType)2, 1721 },
	{ (Il2CppRGCTXDataType)3, 7012 },
	{ (Il2CppRGCTXDataType)3, 4110 },
	{ (Il2CppRGCTXDataType)2, 996 },
	{ (Il2CppRGCTXDataType)2, 1043 },
	{ (Il2CppRGCTXDataType)3, 2989 },
	{ (Il2CppRGCTXDataType)3, 2988 },
	{ (Il2CppRGCTXDataType)2, 1710 },
	{ (Il2CppRGCTXDataType)3, 6980 },
	{ (Il2CppRGCTXDataType)3, 8437 },
	{ (Il2CppRGCTXDataType)2, 1720 },
	{ (Il2CppRGCTXDataType)3, 7011 },
	{ (Il2CppRGCTXDataType)3, 4102 },
	{ (Il2CppRGCTXDataType)2, 1215 },
	{ (Il2CppRGCTXDataType)2, 1717 },
	{ (Il2CppRGCTXDataType)3, 6998 },
	{ (Il2CppRGCTXDataType)3, 2987 },
	{ (Il2CppRGCTXDataType)3, 2986 },
	{ (Il2CppRGCTXDataType)3, 4103 },
	{ (Il2CppRGCTXDataType)2, 1709 },
	{ (Il2CppRGCTXDataType)3, 6979 },
	{ (Il2CppRGCTXDataType)3, 8436 },
	{ (Il2CppRGCTXDataType)2, 1716 },
	{ (Il2CppRGCTXDataType)3, 6997 },
	{ (Il2CppRGCTXDataType)3, 4116 },
	{ (Il2CppRGCTXDataType)2, 1217 },
	{ (Il2CppRGCTXDataType)2, 1725 },
	{ (Il2CppRGCTXDataType)3, 7028 },
	{ (Il2CppRGCTXDataType)3, 4431 },
	{ (Il2CppRGCTXDataType)3, 2201 },
	{ (Il2CppRGCTXDataType)3, 2991 },
	{ (Il2CppRGCTXDataType)3, 2990 },
	{ (Il2CppRGCTXDataType)3, 2200 },
	{ (Il2CppRGCTXDataType)3, 4117 },
	{ (Il2CppRGCTXDataType)2, 1711 },
	{ (Il2CppRGCTXDataType)3, 6981 },
	{ (Il2CppRGCTXDataType)3, 8438 },
	{ (Il2CppRGCTXDataType)2, 1724 },
	{ (Il2CppRGCTXDataType)3, 7027 },
	{ (Il2CppRGCTXDataType)3, 2981 },
	{ (Il2CppRGCTXDataType)3, 2982 },
	{ (Il2CppRGCTXDataType)3, 2992 },
	{ (Il2CppRGCTXDataType)2, 429 },
	{ (Il2CppRGCTXDataType)3, 29 },
	{ (Il2CppRGCTXDataType)3, 6038 },
	{ (Il2CppRGCTXDataType)2, 1526 },
	{ (Il2CppRGCTXDataType)3, 6055 },
	{ (Il2CppRGCTXDataType)2, 479 },
	{ (Il2CppRGCTXDataType)3, 449 },
	{ (Il2CppRGCTXDataType)3, 6044 },
	{ (Il2CppRGCTXDataType)3, 2174 },
	{ (Il2CppRGCTXDataType)2, 320 },
	{ (Il2CppRGCTXDataType)3, 6039 },
	{ (Il2CppRGCTXDataType)2, 1522 },
	{ (Il2CppRGCTXDataType)3, 477 },
	{ (Il2CppRGCTXDataType)2, 491 },
	{ (Il2CppRGCTXDataType)2, 673 },
	{ (Il2CppRGCTXDataType)3, 2183 },
	{ (Il2CppRGCTXDataType)3, 6040 },
	{ (Il2CppRGCTXDataType)3, 2169 },
	{ (Il2CppRGCTXDataType)3, 2170 },
	{ (Il2CppRGCTXDataType)3, 2168 },
	{ (Il2CppRGCTXDataType)3, 2171 },
	{ (Il2CppRGCTXDataType)2, 669 },
	{ (Il2CppRGCTXDataType)2, 2083 },
	{ (Il2CppRGCTXDataType)3, 2980 },
	{ (Il2CppRGCTXDataType)3, 2173 },
	{ (Il2CppRGCTXDataType)2, 939 },
	{ (Il2CppRGCTXDataType)3, 2172 },
	{ (Il2CppRGCTXDataType)2, 880 },
	{ (Il2CppRGCTXDataType)2, 2047 },
	{ (Il2CppRGCTXDataType)2, 973 },
	{ (Il2CppRGCTXDataType)2, 1024 },
	{ (Il2CppRGCTXDataType)3, 2646 },
	{ (Il2CppRGCTXDataType)2, 694 },
	{ (Il2CppRGCTXDataType)3, 3195 },
	{ (Il2CppRGCTXDataType)3, 3196 },
	{ (Il2CppRGCTXDataType)3, 3201 },
	{ (Il2CppRGCTXDataType)2, 1076 },
	{ (Il2CppRGCTXDataType)3, 3198 },
	{ (Il2CppRGCTXDataType)3, 8719 },
	{ (Il2CppRGCTXDataType)2, 674 },
	{ (Il2CppRGCTXDataType)3, 2193 },
	{ (Il2CppRGCTXDataType)1, 936 },
	{ (Il2CppRGCTXDataType)2, 2055 },
	{ (Il2CppRGCTXDataType)3, 3197 },
	{ (Il2CppRGCTXDataType)1, 2055 },
	{ (Il2CppRGCTXDataType)1, 1076 },
	{ (Il2CppRGCTXDataType)2, 2097 },
	{ (Il2CppRGCTXDataType)2, 2055 },
	{ (Il2CppRGCTXDataType)3, 3202 },
	{ (Il2CppRGCTXDataType)3, 3200 },
	{ (Il2CppRGCTXDataType)3, 3199 },
	{ (Il2CppRGCTXDataType)2, 212 },
	{ (Il2CppRGCTXDataType)3, 2202 },
	{ (Il2CppRGCTXDataType)2, 310 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	121,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	41,
	s_rgctxIndices,
	199,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
