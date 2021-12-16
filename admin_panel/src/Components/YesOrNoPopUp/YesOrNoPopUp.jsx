import React from "react";
import { Popup } from "devextreme-react/popup";
import { Button } from "devextreme-react/button";
function YesOrNoPopUp({ setdialog, dailog, OnDelete }) {
  return (
    <div>
      <Popup
        maxWidth={1000}
        title={""}
        minWidth={150}
        minHeight={100}
        height={200}
        width={350}
        showTitle={true}
        dragEnabled={false}
        closeOnOutsideClick={true}
        visible={dailog.state}
        onHiding={() => setdialog(false)}
      >
        <div className="contianer" style={{ textAlign: "center" }}>
          <h3>Are you sure ? </h3>
          <div
            className="row"
            style={{ display: "flex", justifyContent: "center" }}
          >
            <div className="col">
              <Button
                width={120}
                text={"Yes"}
                type="normal"
                stylingMode="contained"
                onClick={() => {
                  OnDelete(dailog.id);
                  setdialog(false);
                }}
              />
            </div>
            <div className="col">
              <Button
                width={120}
                text="No"
                type="normal"
                stylingMode="contained"
                onClick={() => setdialog(false)}
              />
            </div>
          </div>
        </div>
      </Popup>
    </div>
  );
}

export default YesOrNoPopUp;
