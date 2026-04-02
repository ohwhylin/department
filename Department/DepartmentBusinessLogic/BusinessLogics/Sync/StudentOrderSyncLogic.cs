using DepartmentContracts.BindingModels;
using DepartmentContracts.BusinessLogicsContracts;
using DepartmentContracts.BusinessLogicsContracts.Sync;
using DepartmentContracts.StoragesContracts;

namespace DepartmentBusinessLogic.BusinessLogics.Sync
{
    public class StudentOrderSyncLogic : IStudentOrderSyncLogic
    {
        private readonly IOneCApiService _oneCService;
        private readonly IStudentOrderStorage _orderStorage;
        private readonly IStudentOrderBlockStorage _blockStorage;
        private readonly IStudentOrderBlockStudentStorage _blockStudentStorage;

        public StudentOrderSyncLogic(
            IOneCApiService oneCService,
            IStudentOrderStorage orderStorage,
            IStudentOrderBlockStorage blockStorage,
            IStudentOrderBlockStudentStorage blockStudentStorage)
        {
            _oneCService = oneCService;
            _orderStorage = orderStorage;
            _blockStorage = blockStorage;
            _blockStudentStorage = blockStudentStorage;
        }

        public async Task SyncStudentOrdersAsync()
        {
            var orders = await _oneCService.GetStudentOrdersAsync();

            foreach (var order in orders)
            {
                // 1. ORDER
                _orderStorage.Insert(new StudentOrderBindingModel
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    StudentOrderType = order.StudentOrderType
                });

                foreach (var block in order.Blocks)
                {
                    // 2. BLOCK
                    _blockStorage.Insert(new StudentOrderBlockBindingModel
                    {
                        Id = block.Id,
                        StudentOrderId = block.StudentOrderId,
                        EducationDirectionId = block.EducationDirectionId,
                        StudentOrderType = block.StudentOrderType
                    });

                    foreach (var student in block.Students)
                    {
                        // 3. BLOCK STUDENT
                        _blockStudentStorage.Insert(new StudentOrderBlockStudentBindingModel
                        {
                            Id = student.Id,
                            StudentOrderBlockId = student.StudentOrderBlockId,
                            StudentId = student.StudentId,
                            StudentGroupFromId = student.StudentGroupFromId,
                            StudentGroupToId = student.StudentGroupToId
                        });
                    }
                }
            }
        }
    }
}
