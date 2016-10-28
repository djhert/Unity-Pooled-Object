# Unity Pooled Object

<B>To Implement:</B> Simply have your game objects inherit from 'PooledObject'.  
MonoBehaviour functions of  Start, Update, FixedUpdate, LateUpdate are not defined here, your objects are able to have these functions defined

<B>Usage: </B> Instantiate an object using "GetPooledInstance<ObjectName>". 
This will pull an object from the pool, if it does not exist it uses the standard Instantiation methods.

An equivalent Start function for 'Pooled Objects' is "PoolStart()".  This is called when an object is pulled from the Pool.  Your object must override this function to use it.

When you are done with the object, use the function "object.ReturnToPool()" to place it back in the pool.

To pre-populate the pool, such as on loading screens, use "FillPool<ObjectName>(amount)" where amount is how many objects are put in the pool.  
