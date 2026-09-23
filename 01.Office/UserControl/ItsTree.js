/// <reference path="../Script/reference.js" />
var _treeParams = function () {
    this.displayColumn = 'title';
    this.autoCollapse = false;
    this.expandOnLoad = false;
};

var ItsTree = {
    list: [],
    /**
     * @param {String} id
     * @param {_TreeParams} params
     */
    Create: function (id, params) {
        params.id = id;
        var $params = new _treeParams();
        ItsHelper.CopyObj(params, $params);

        if ($params.id == undefined) {
            alert('Tree control must have attribute \'id\'.');
            return;
        }
        if ($('#' + $params.id).length == 0) {
            alert('Can not find \'' + $params.id + '\' tag.');
            return;
        }
        var $obj = new wijmo.nav.TreeView('#' + $params.id, {
            displayMemberPath: $params.displayColumn,
            childItemsPath: 'items',
            isAnimated: false,
            expandOnLoad: $params.expandOnLoad,
            autoCollapse: $params.autoCollapse,
            selectedItemChanged: function (s, e) {
                try{
                    ItsTree.Event($params.id).onSelect(s.selectedNode.index, s.selectedItem);
                } catch(e) { }
            }
        });
        ItsTree.list.push($obj);
        $obj.childItem = $params.childItem;
        return $obj;
    },
    Get: function (id) {
        try {
            for (var i = 0; i < ItsTree.list.length; i++) {
                if (id == ItsTree.list[i]._e.id) {
                    return ItsTree.list[i];
                }
            }
        } catch (e) { return undefined; }

    },
    Length: function (id) {
        var $obj = ItsTree.Get(id);
        try {
            return $obj.itemsSource.length;
        } catch (e) {
            return 0;
        }
    },
    Clear: function (id) {
        ItsTree.SetStore(id, new Store());
    },
    GetStore: function (id) {
        var $obj = ItsTree.Get(id);
        try {
            return $obj.itemsSource;
        } catch (e) {
            return 0;
        }
    },
    SetStore: function (id, store, selectIndex) {
        var $obj = ItsTree.Get(id);
        $obj.itemsSource = store.data;
    },
    SetRelation: function (id, store, key, parentCode) {
        var $obj = ItsTree.Get(id);
        var oldData = [];
        store.data.forEach(function (node) {
            if (node[key] == node[parentCode]) {
                node[parentCode] = null;
            }
            oldData.push(node);
        });
        var dataMap = oldData.reduce(function (map, node) {
            map[node[key]] = node;
            return map;
        }, {});
        var tree = [];
        oldData.forEach(function (node) {
            var parent = dataMap[node[parentCode]];
            if (parent) {
                (parent.items || (parent.items = []))
                    .push(node);
            } else {
                tree.push(node);
            }
        });
        store.data = tree;
    },
    /** 
    @returns {ItsTree.Listener} 
    */
    Event: function (key) {
        if (ItsPage.EventList[key] == undefined) {
            ItsPage.EventList[key] = new ItsTree.Listener();
        }
        return ItsPage.EventList[key];
    },
    Listener: function () {
        this.onSelect = function (rowIndex, data) { };
    }
};