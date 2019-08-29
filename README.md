# GameFramework


GFrame
------Scripts
      ------Engine
            ------DataRecord   存档
                  ------DataClassHandler
                        存档的核心类
                        
                  ------DataDirtyHandler
                        主要提供了数据是否需要保存的相关方法
                  ------IDataClass
                        继承了DataDirtyHandler，提供了InitWithEmptyData()和OnDataLoadFinish()方法
                   

