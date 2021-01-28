namespace PALProgrammingWebTest.ViewModels {
    public class HelperVM {

        public virtual PALModels db { get; set; }
        public HelperVM() {
            db = new PALModels();
        }
    }
}
