import React, { useCallback } from "react";
import { Popup } from "devextreme-react/popup";
import ScrollView from "devextreme-react/scroll-view";
import SubmitButtons from "../Buttons/SubmitButtons";
function PopUpModel({ setdialog, dailog, children, Submit }) {
  return (
    <div>
      <Popup
        maxWidth={1000}
        title={""}
        minWidth={150}
        minHeight={500}
        showTitle={true}
        dragEnabled={false}
        closeOnOutsideClick={true}
        visible={dailog}
        onHiding={() => setdialog(false)}
      >
        <ScrollView showScrollbar="onHover">
          <form
            onSubmit={(e) => {
              e.preventDefault();
              Submit();
            }}
          >
            {children}
            <SubmitButtons />
          </form>
        </ScrollView>
      </Popup>
    </div>
  );
}

export default PopUpModel;
