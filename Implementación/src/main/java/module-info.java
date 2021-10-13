module com.uv.projectoradio {
    requires javafx.controls;
    requires javafx.fxml;

    requires org.controlsfx.controls;
    requires com.dlsc.formsfx;
    requires org.kordamp.bootstrapfx.core;

    opens com.uv.projectoradio to javafx.fxml;
    exports com.uv.projectoradio;
}