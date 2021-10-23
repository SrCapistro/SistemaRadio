module com.uv.myradiocontroller {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.controlsfx.controls;
    requires com.dlsc.formsfx;
    requires java.sql;

    opens com.uv.myradiocontroller to javafx.fxml;
    exports com.uv.myradiocontroller;
}