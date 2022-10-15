namespace fitnessManagementSystem.App
{
    public static class AppConstants
    {
        public const string SuccessMessage = "Data saved successfully";
        public const string UpdatedMessage = "Data updated successfully";
        public const string DeletedMessage = "Data deleted successfully";
        public const string FailureMessage = "Something happeed! Please try later";
        public const string DataNotFoundMessage = "Data Not Found";

        public static ResponseModel SaveSuccess(object data = null, string message = AppConstants.SuccessMessage)
        {
            return new ResponseModel
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
        public static ResponseModel UpdateSuccess(object data = null, string message = AppConstants.UpdatedMessage)
        {
            return new ResponseModel
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
        public static ResponseModel DeleteSuccess(object data = null, string message = AppConstants.DeletedMessage)
        {
            return new ResponseModel
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
        public static ResponseModel Success(object data = null)
        {
            return new ResponseModel
            {
                Success = true,
                Message = String.Empty,
                Data = data,
            };
        }
        public static ResponseModel Error( object data = null, string message = AppConstants.FailureMessage)
        {
            return new ResponseModel
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
    }
}
